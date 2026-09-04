# OrtoBuildingDetectionModel — provenance

What `OrtoBuildingDetectionModel.mlnet` was trained on, how it was measured, and what was decided along the way. Without this, the next person cannot tell which data a model came from.

**Trained 2026-09-02.**

| | |
|---|---|
| Model file | `OrtoBuildingDetectionModel.mlnet`, 45.5 MB |
| SHA-256 | `dff63d8a6c205eeb470de7a1c8ef685a1072c143e63adc34ee05ca7a4f0de59a` |
| Trainer | `LightGbmRegression`, selected by AutoML over 609 trials in 3 600 s |
| Tool | `mlnet-win-x64` 16.18.2 — **not** Model Builder, which cannot run on Visual Studio 2026 (its AutoML binds `Microsoft.CodeAnalysis.CSharp` 4.9.0.0; VS 2026 ships 5.900) |

## Sibling partials

`OrtoBuildingDetectionModel.consumption.cs` is regenerated on every retrain. `OrtoBuildingDetectionModel.readiness.cs` is a **hand-maintained** partial of the same type (the model-file readiness probe for the Year Built predictor preflight) and reads the generated file's private `MLNetModelPath`. A retrain must keep that resolver, or the readiness partial stops compiling — loudly, not silently. Keep the two files together when re-establishing the model.

## Data

| | |
|---|---|
| Rows | 20 241, one per labelled building, no duplicate references |
| Features | 172 (+ `Reference` ignored, `Year built` label) = 174 columns |
| Feature list SHA-256 | `f46f088cabcc701311e39e8953de688a2cf4316b5b6fd958c5e8ff7c71793d29` |
| Source | `building_data` and `year_built_data` on `api.digiproject.uk`, via `YearBuiltPredictionTrainingTableConsoleApp` |

### Counties

| Id | Name | Labelled rows |
|---|---|---|
| 5 | bolesławiecki | 10 440 |
| 80328 | m. Świętochłowice | 4 338 |
| 75125 | m. Sopot | 3 640 |
| 104106 | m. Świnoujście | 1 823 |

These are the only counties carrying `year_built_data`. Three of the four are small city counties and one is rural, so **nothing here establishes that the model transfers to the rest of Poland.**

### Labels

Taken from a non-prediction entry of the stored `YearBuiltData` only. Every record on these counties also carries the previous model's answer, stamped 2025-05-29, disagreeing with the user-supplied year on 26–28 % of records; taking whichever year a record listed first would have trained this model on its predecessor.

Reconciled against the legacy `Data/Data_2025.05.27.tsv` on the 20 236 shared references: **identical on all 20 236**.

**The label is not a historical construction year.** It is the first year the building appears in the orthophoto record, floored at the earliest imagery year. 84.2 % of rows carry `2008`; there are 17 distinct values.

## Measurement

Holdout membership is decided by FNV-1a hash of the reference (`Query.Split`), not by a seeded shuffle, so the same carve reproduces in any language or runtime.

The metrics below come from a **separately trained twin** — same tool, same settings, trained on the 16 229 non-holdout rows only — because the shipped model was trained on all 20 241 and cannot be honestly scored on any of them. The shipped model is expected to do slightly better than this, having seen more data.

Measured on 4 012 rows the twin never saw:

| Predictor | MAE (years) | RMSE | R² |
|---|---|---|---|
| constant 2008 | 1.453 | 4.010 | −0.151 |
| previous model, through the deployed path | 5.434 | 6.221 | −1.771 |
| **first detection year** (a ten-line rule) | **0.434** | 1.730 | 0.786 |
| **this model (twin)** | 0.476 | **1.217** | **0.894** |

**This model does not beat the trivial heuristic outright.** It wins on RMSE and R² and loses on MAE. The heuristic is exactly right on 89.2 % of rows but 3.8 % of its errors are 5 years or more, worst case 16; this model is exactly right less often with a much tighter tail. Whether that trade is worth making is a product decision — see [#4](https://github.com/ZiolkowskiJakub/DiGi.GIS.ML/issues/4).

The previous model's −1.771 is not a fair reading of what it once was. It binds legacy display names (`Area`, `Location X`, `Polpulation 2008`) that no longer exist, so it reads defaults for most features. It is what that model would have produced on current data.

### Not measured

**The grouped-by-subdivision split has never been validly measured for any model.** Both figures produced so far came from models trained on part of the holdout. The control for memorised neighbourhoods is therefore still outstanding; the heuristic scores alike on both carves (0.786 random, 0.789 grouped), which is suggestive but is not evidence about the model.

## Decisions

| Decision | Why |
|---|---|
| `Subdivision name` kept as a categorical feature | Only 115 values across four counties, not the thousands a national set would carry. The grouped split is the intended control rather than pre-emptive dropping |
| `County Id` / `Subdivision Id` numeric, not categorical | Ordinal identifiers; the names carry the categorical signal |
| `Building specific functions` kept whole (298 distinct) | Multi-valued text left as one category rather than split or hashed. Revisit if it proves to be memorising |
| `Municipality population 2024`, `2025` kept | Zero on every row — the BDL series does not reach them. Two dead features, left in to keep the schema aligned with the allow-list |
| Year range 2008–2025 | Held for this cycle; 2026 is [DiGi.GIS.IO#10](https://github.com/ZiolkowskiJakub/DiGi.GIS.IO/issues/10) |
| `TrainingTime` 3 600 s | The search plateaus early — best R² moved 0.8858 at 18 models to 0.8947 at 609 |

## Source

| Repository | Commit |
|---|---|
| `DiGi.GIS.ML` | `9470258` |
| `DiGi.GIS.IO` | `08c4a57` |
| `DiGi.Core` | `58d548b` |

Reports: `DiGi.Test/user files/reports/YearBuiltPrediction_Accuracy_Clean.txt`, `YearBuiltPrediction_Baselines.txt`.
