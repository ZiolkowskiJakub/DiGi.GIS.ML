# OrtoBuildingDetectionModel — provenance

What `OrtoBuildingDetectionModel.mlnet` was trained on, how it was measured, and what was decided along the way. Without this, the next person cannot tell which data a model came from.

## Retired from production 2026-10-09 (ZiolkowskiJakub/DiGi.GIS.ML#15)

**The year built is no longer predicted by this model.** `Query.PredictedYearBuilts` now uses the first-detection heuristic: the first year the detector saw the building with confidence ≥ 0.5, falling back to the first year with any detection. A building that was never detected is left out. The runner stamps `first-confident-detection@0.5` (`Constants.Heuristic.Id`) on every prediction instead of a model SHA-256. The model, its generated code and the training and evaluation tools stay here as the baseline for the parked feature redesign (ZiolkowskiJakub/DiGi.GIS.ML#17). Any new model has to beat the heuristic on a county it was not trained on before it returns to production.

### Why: the regressor does not transfer to a county it was not trained on

#15 set out to retrain without absolute coordinates and identity features, because #14 had shown that coordinates move the predictions. To measure transfer honestly, twins were trained **without county 80328** (`mlnet` 16.18.2, 3 600 s each, three or two in parallel) and scored on 80328 (labelled, 4 340 rows) and on county part 8956 (unlabelled, 5 579 buildings). "Late" means predicted later than the first confident detection year. The healthy band on the labelled counties had been ≤ 16 %.

| Twin, trained without 80328 | Feature change | 80328 MAE / RMSE / R² | 80328 late | 8956 late |
|---|---|---|---|---|
| — | first-detection heuristic, no model | **0.145 / 0.844 / 0.957** | **0 %** | **0 %** |
| A0 | none (the #13 feature list) | 1.377 / 1.657 / 0.834 | 76.6 % | 89.6 % |
| A1 | minus coordinates, `County Id`, `Subdivision Id`, the four place names | 3.160 / 3.462 / 0.276 | 88.0 % | 78.0 % |
| A2 | A1 minus `Municipality population 2008–2025` | 3.038 / 3.308 / 0.339 | 88.2 % | 80.9 % |
| C0 | none; detection columns of a year the county has no imagery for set to `-1` | 4.513 / 4.903 / −0.453 | 89.0 % | 83.3 % |
| C1 | A1 + the `-1` marker | 4.111 / 4.472 / −0.209 | 88.0 % | 82.4 % |

A run B0/B1 left the no-imagery cells empty instead of `-1`. It is not a test of anything: ML.NET's text loader reads an empty numeric cell as `0`, so B repeated A.

The same A1 twin scores county 5, which it was trained on, at MAE 0.106 and 2.6 % late. The labels are clean: 96–99 % of buildings first confidently detected in 2008 are labelled 2008 or 2009 in every large county. **The models memorise the counties they are trained on.** Coordinates were one way to recognise a county. The 18 per-year detection columns are another: every county has its own pattern of orthophoto years (80328: 2008, 2012, 2015, 2018, 2019, 2021–2024; county 5: 2008, 2010, 2013–2015, 2017, 2019–2021, 2023), so the county stays recognisable without coordinates. AutoML selects on a random row split, so it validates on the counties it trains on and rewards that memorisation. The 4–16 % "healthy" shares #14 measured on labelled counties were fits, not evidence of transfer.

### The heuristic on the #13 carves (deployed path, `YearBuiltTraining_train9.tsv`)

The model twin `cc815ded…` was trained on these counties, so this comparison favours it. The twin figures are its deployed-path figures from the section below.

| Carve | n | heuristic (MAE / RMSE / R²) | #13 twin | previous heuristic, any confidence > 0 |
|---|---|---|---|---|
| full table, random 20 % | 4 953 | **0.246** / 1.413 / 0.870 | 0.338 / **1.271** / **0.896** | 0.358 / 1.797 / 0.791 |
| #4 carve, old estate without 204 | 4 011 | **0.198** / 1.233 / 0.891 | 0.277 / **1.129** / **0.909** | 0.285 / 1.583 / 0.821 |
| five old-estate counties | 4 774 | **0.209** / 1.268 / 0.882 | 0.304 / **1.192** / **0.897** | 0.301 / 1.632 / 0.806 |

On counties it has seen, the model keeps a slightly tighter error tail (RMSE, R²). The heuristic wins on MAE everywhere, and on an unseen county it wins on every metric. Requiring confidence ≥ 0.5 before falling back cuts the old rule's MAE by about 30 %. Seven rows of the full table carry no detection at all and are left out, which is why n is 4 953 rather than 4 956. **Not measured:** the 179-row clean holdout, because its manifest is in the YOLO training directory and not on the measuring machine.

Buildings dated per county through the deployed path, from `--unlabelled` tables read from `api.digiproject.uk` on 2026-10-09:

| County | confident detection | weaker detection only | never detected, left out |
|---|---|---|---|
| 8956 | 5 536 | 11 | 32 |
| 80328 | 4 428 | 13 | 0 |
| 5 | 33 502 | 137 | 48 |
| 204 | 3 794 | 5 | 26 784 (detections were written for the labelled buildings only) |
| 75125 | 4 111 | 12 | 2 |
| 104106 | 5 525 | 12 | 2 |

Reproduce:
- `YearBuiltPredictionTrainingTableConsoleApp --unlabelled --counties <id> --output <t.tsv>` builds the table of every building in a county.
- `YearBuiltPredictionEvaluationConsoleApp --table <t.tsv> [--model <twin.mlnet>]` reports accuracy when the table is labelled and always reports plausibility.
- Reports, tables and twins are in DiGi.GIS.ML `user files/reports/noloc/` on the measuring machine.

| Repository | Commit |
|---|---|
| `DiGi.GIS.ML` | `ef852e7` (+ this change) |
| `DiGi.GIS.IO` | `98df693` |
| `DiGi.Core` | `5ecfa59` |
| `DiGi.GIS.YOLO.UI` | `94a500f` |

---

## Shipped 2026-10-08 (ZiolkowskiJakub/DiGi.GIS.ML#13), retired from production 2026-10-09

The model in this folder. It was trained on the detection features of the retrained YOLO detector **`train9_fresh`** (YOLO26x, SHA-256 `2dd833e438ffcb1352ae7675063c9f0c97ca1c39ce6410a0bfab96e8b3cbdc9a`, ZiolkowskiJakub/DiGi.GIS.YOLO.UI#12). **It is only valid with that detector:** a deployment scoring with `train8` detections hands it features it was never fitted on.

| | |
|---|---|
| Model file | `OrtoBuildingDetectionModel.mlnet`, 84 792 169 B |
| SHA-256 | `2e120f495e830f0917cace33ad21c5c4c7bb0c4e8f1711a363682932b7c0b7fa` |
| Trainer | `LightGbmRegression`, selected by AutoML over 237 trials in 3 600 s |
| Tool | `mlnet-win-x64` 16.18.2, `mlnet train --training-config` with this folder's `.mbconfig` |
| Detector the features came from | `train9_fresh`, SHA-256 `2dd833e4…dc9a` |

### Data

| | |
|---|---|
| Table | 25 008 rows × 174 columns, one per labelled building. Built by `YearBuiltPredictionTrainingTableConsoleApp --counties <217 ids>` as `user files/reports/YearBuiltTraining_train9.tsv` on the GPU machine |
| Counties | the 217 counties holding a `User year built` label. The five old-estate counties carry 24 047 rows (5: 10 443, 80328: 4 340, 204: 3 801, 75125: 3 640, 104106: 1 823); 212 newly labelled counties carry 961 |
| Labels | the stored `User year built` column: 19 distinct values, 81.1 % `2008` |
| Feature list | unchanged. The header is byte-identical to the #11 table's; 2 of 174 columns are constant (`Municipality population 2024`, `2025`) |
| Detection features | the `train9_fresh` detections, written for the 25 007 labelled references with the replacing write of ZiolkowskiJakub/DiGi.GIS.YOLO.UI#21. No `train8` value survives on these buildings (verified on all 1 823 of county 104106) |

### Configuration

The `.mbconfig` is the one ZiolkowskiJakub/DiGi.GIS.ML#11's twin was trained with, and `ColumnProperties` and `TrainingOption` here record it.
- The ten text columns are **not** marked categorical: AutoML featurizes them as text instead of one-hot encoding them.
- `Is residential` and `Is occupied` are booleans converted to a number.

The 2026-09-02 model one-hot encoded all twelve, so the generated `ModelOutput` changed in two members (`Is_residential` and `Is_occupied` are now `float`). `ModelInput`, `TrainedYears` (2008..2025) and `TrainedRadiuses` (the defaults) are unchanged.

### Measurement

The holdout is the FNV-1a holdout of the reference, the `Test` category of the YOLO dataset manifest. It reproduces #11's carve exactly (4 777 / 4 777) and adds 179 references. A **twin** was trained the same way on the 20 052 non-holdout rows only (SHA-256 `cc815dede03e4e3be8cf6a9d3d2c12183f0659a451513c7ee55cab6d492888cb`, 178 trials). All figures below are the twin scored on rows it never saw, **through the deployed path** (`Query.PredictedYearBuilts`, the binding production uses).

| Carve | n | first detection year (MAE / RMSE / R²) | twin (MAE / RMSE / R²) |
|---|---|---|---|
| full table, random 20 % | 4 956 | 0.358 / 1.797 / 0.791 | **0.338 / 1.271 / 0.896** |
| clean: holdout ∧ ¬`Legacy` | 179 | 1.894 / 4.283 / −0.075 | **1.251 / 2.609 / 0.601** |
| old estate without 204 (the [#4](https://github.com/ZiolkowskiJakub/DiGi.GIS.ML/issues/4) carve) | 4 012 | 0.285 / 1.583 / 0.821 | **0.277 / 1.129 / 0.909** |
| five old-estate counties (#11's carve) | 4 777 | **0.301** / 1.632 / 0.806 | 0.304 / **1.192** / **0.897** |

- **Against what it replaces, on the clean row** (no model has seen these buildings): the 2026-09-02 model, scored on the same `train9_fresh` features, gives 2.246 / 3.469 / 0.294. This twin gives 1.251 / 2.609 / 0.601. Constant 2008 gives 8.184 / 9.167 / −3.93. This is ZiolkowskiJakub/DiGi.GIS.ML#13's ship rule, and it is met.
- **Against #11's twin on the same 4 777 references:** the #11 twin on `train8` features scores 0.600 / 1.654 / 0.801 through the deployed path; this twin on `train9_fresh` features scores 0.304 / 1.192 / 0.897.
- **The [#4](https://github.com/ZiolkowskiJakub/DiGi.GIS.ML/issues/4) bar is met**: MAE, RMSE and R² all beat the heuristic on the #4 carve and on the full table. It ties on MAE only on the five-county carve, by 0.003.

**The two scoring paths of `YearBuiltPredictionEvaluationConsoleApp` disagree.** The `retrained` row loads the table with ML.NET's `TextLoader`, as `mlnet` does at training time. The `deployed path` row binds each row to `ModelInput`, as production does. For one and the same model, the `retrained` row reads about 0.07–0.09 years **higher** MAE (twin: 0.414 vs 0.338 on the full table; #11 twin: 0.689 vs 0.600). RMSE and R² agree to within 0.01. The cause is not yet established; the likely suspect is how an empty cell reaches the missing-value replacement in each path. The figures first posted on #13, and the #11 hold decision, were read through the `retrained` path. #11's twin scores 0.600 against the heuristic's 0.568 through the deployed path, so the hold stands.

**Not measured:** a valid grouped-by-subdivision carve. A twin trained on everything outside the *reference* holdout has seen most rows of any subdivision carve, so the grouped row of the evaluation report is contaminated for it (this twin: 0.134). Measuring it needs a twin trained without that carve.

Reports (DiGi.GIS.ML `user files/reports/`, GPU machine): `eval_G_twin_deployedpath.txt`, `eval_G_twin_deployedpath_old5.txt`, `eval_G_twin_deployedpath_no204.txt`, `eval_H_11twin_deployedpath.txt`; through the `retrained` path, `eval_A`–`eval_E`. A check that the shipped model really is the one installed: `eval_F_shipped_deployedpath.txt` (contaminated, since it saw these rows).

| Repository | Commit |
|---|---|
| `DiGi.GIS.ML` | `5ff37f8` (+ this change) |
| `DiGi.GIS.IO` | `9221834` |
| `DiGi.Core` | `1c6d031` |
| `DiGi.GIS.YOLO.UI` | `9bee001` (detection write and `ReferencesFilePath`) |

---

## Previous model: trained 2026-09-02, replaced 2026-10-08

Trained on `train8` detection features. Kept as the record of the model shipped from 2026-09-02 to 2026-10-08.

| | |
|---|---|
| Model file | `OrtoBuildingDetectionModel.mlnet`, 45.5 MB |
| SHA-256 | `dff63d8a6c205eeb470de7a1c8ef685a1072c143e63adc34ee05ca7a4f0de59a` |
| Trainer | `LightGbmRegression`, selected by AutoML over 609 trials in 3 600 s |
| Tool | `mlnet-win-x64` 16.18.2 — **not** Model Builder, which cannot run on Visual Studio 2026 (its AutoML binds `Microsoft.CodeAnalysis.CSharp` 4.9.0.0; VS 2026 ships 5.900) |

## Sibling partials

`OrtoBuildingDetectionModel.consumption.cs` is regenerated on every retrain. `OrtoBuildingDetectionModel.readiness.cs` is a **hand-maintained** partial of the same type (the model-file readiness probe for the Year Built predictor preflight) and reads the generated file's private `MLNetModelPath`. A retrain must keep that resolver, or the readiness partial stops compiling — loudly, not silently. Keep the two files together when re-establishing the model.

The trained contract — `TrainedYears` and `TrainedRadiuses` — also lives in `OrtoBuildingDetectionModel.readiness.cs`, not in the generated file, for the same reason: a retrain regenerates the generated file and would revert any contract written there in silence. A retrain must update both to the new range, or the orchestrator refuses every run whose options match the old range and the `FeatureContract` fact fails against the regenerated `ModelInput`.

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

### The cost of a narrowed projection ([#6](https://github.com/ZiolkowskiJakub/DiGi.GIS.ML/issues/6))

Measured with `YearBuiltPredictionEvaluationConsoleApp --years 2008..2020` on the 20 241 training rows, scoring the shipped model through the deployed path. This is a fit, not a holdout - the model has seen these rows - so the absolute figures are optimistic, but the relative delta between the full and the narrowed projection is what the feature-contract guard sizes:

| Split | MAE (years) | RMSE | R² |
|---|---|---|---|
| full 2008..2025, random 20% | 0.107 | 0.646 | 0.970 |
| narrowed 2008..2020, random 20% | 0.650 | 1.344 | 0.871 |
| full 2008..2025, grouped 20% | 0.103 | 0.617 | 0.975 |
| narrowed 2008..2020, grouped 20% | 0.685 | 1.423 | 0.868 |

Narrowing the projection to 2008..2020 drops R² by about 0.10 and multiplies the MAE by roughly six. The silent degradation is not small - which is exactly why the guard refuses a narrowed options file rather than warning about it.

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

---

## Retrained 2026-09-29 (ZiolkowskiJakub/DiGi.GIS.ML#11) — held

The retrain on the stored `User year built` label source ran on 2026-09-29 and was **held**: no model was shipped, so this file above remains the record of the shipped model.

### What was trained

| | |
|---|---|
| Table | 24 047 rows × 174 columns, one per labelled building; `user files/reports/YearBuiltTraining.tsv` (this machine) |
| Counties | 5 (10 443 rows), 204 (3 801, newly labelled by the national update), 75125 (3 640), 80328 (4 340), 104106 (1 823) |
| Labels | the stored `User year built` column — most frequent exact user year, read, not re-derived: 18 distinct values `2008–2025`, 84.2 % `2008`. The incumbent's 20 241 references keep their labels exactly; +3 806 new references |
| Feature list | unchanged — the table header is byte-identical to the incumbent table's (SHA-256 `71597d07…85b`); 2 of 174 columns constant (the two dead population years) |
| Models | `mlnet` CLI 16.18.2, `LightGbmRegression` selected by AutoML over 3 600 s each: shipped candidate on all 24 047 rows (SHA-256 `1915d3f5…de7`), twin on the 19 270 non-holdout rows (SHA-256 `a11d3e81…2c`) |
| Holdout | FNV-1a of the reference, 1 in 5 — 4 777 rows on the full table, matching `Query.Split` and the evaluation app exactly |

### Measurement (twin — it never saw these rows)

On the full 24 047-row table:

| Split | Predictor | MAE (years) | RMSE | R² |
|---|---|---|---|---|
| random 20 % (by reference) | constant 2008 | 1.423 | 3.973 | −0.147 |
| random 20 % (by reference) | first detection year | 0.568 | 2.189 | 0.652 |
| random 20 % (by reference) | deployed path (incumbent) | 1.492 | 3.706 | 0.002 |
| random 20 % (by reference) | **this retrain (twin)** | **0.689** | **1.646** | **0.803** |
| grouped 20 % (by subdivision) | constant 2008 | 1.552 | 4.141 | −0.164 |
| grouped 20 % (by subdivision) | first detection year | 0.654 | 2.292 | 0.644 |
| grouped 20 % (by subdivision) | deployed path (incumbent) | 1.777 | 4.020 | −0.097 |
| grouped 20 % (by subdivision) | **this retrain (twin)** | **0.307** | **1.005** | **0.932** |

Isolation on the old-estate rows only — the 20 246 rows that are not county 204, same holdout rule, n = 4 012:

| Predictor | MAE (years) | RMSE | R² |
|---|---|---|---|
| constant 2008 | 1.453 | 4.010 | −0.151 |
| first detection year — **reproduces the [#4](https://github.com/ZiolkowskiJakub/DiGi.GIS.ML/issues/4) bar exactly** | 0.434 | 1.730 | 0.786 |
| **this retrain (twin)** | **0.480** | **1.230** | **0.892** |

The deployed-path row is valid only on the full table: the incumbent was trained on every old-estate row, so a carve of old rows alone is a fit for it, and its full-table figure is dominated by county 204, which it was never fitted on. The shipped candidate scored MAE 0.270 / RMSE 0.822 / R² 0.951 on the full-table random carve — **contaminated**, it saw those rows in training; kept for the contrast.

### Why held

The [#4](https://github.com/ZiolkowskiJakub/DiGi.GIS.ML/issues/4) bar — beat MAE 0.434, RMSE 1.730 and R² 0.786 simultaneously on a holdout the model has not seen, split stated — is not met: the twin's MAE is 0.689 on the full table and 0.480 on the old estate, against the 0.434 bar; RMSE and R² pass on both carves. The retrain leaves the incumbent's MAE-versus-heuristic trade essentially unchanged — the previous twin scored 0.476 / 1.217 / 0.894 on the same 4 012-row carve (administrative features on 9 699 old rows have drifted since, so the two twins are near, not identical, comparisons).

Two things the measurement does settle:

- ~~**The grouped-by-subdivision split has now been validly measured for a model**~~. **Withdrawn 2026-10-08 (#13).** The twin was trained on everything outside the *reference* holdout, so most rows of the subdivision carve were in its training data. Its 0.307 there is contaminated and says nothing about memorised neighbourhoods.
- **The heuristic itself degrades on the new table** (0.568 / 2.189 / 0.652 against the old 0.434 / 1.730 / 0.786) — county 204 and the stored-column labels are harder territory, for the model and for the ten-line rule alike.

The incumbent stays shipped. The retrain's table and both models are kept in `user files/reports/` for ZiolkowskiJakub/DiGi.GIS.ML#13, which re-scores after the YOLO detector retrain rewrites the detection features.

Reports: `DiGi.Test/user files/reports/YearBuiltPrediction_Accuracy_Clean_2026-09-29.txt` (twin, full table), `YearBuiltPrediction_Accuracy_2026-09-29.txt` (shipped candidate, contaminated), `YearBuiltPrediction_Accuracy_No204_2026-09-29.txt` (twin, old estate).

| Repository | Commit |
|---|---|
| `DiGi.GIS.ML` | `c4d1e67` |
| `DiGi.GIS.IO` | `39a8670` |
| `DiGi.Core` | `d9c1487` |
