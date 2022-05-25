import { PayloadAction } from "@reduxjs/toolkit";
import langApi from "api/langApi";
import { IBasePaging, IFilterBodyRequest, ILangViewModel } from "models";
import { call, put, takeLatest } from "redux-saga/effects";
import functionApi from "../api/functionApi";
import { globalActions } from "./globalSlice";

function* sagaGlobalFetchLangs(action: PayloadAction<IFilterBodyRequest>) {
  try {
    const res: IBasePaging<ILangViewModel> = yield call(
      langApi.getAll,
      action.payload
    );
    yield put(globalActions.fetchGlobalLangsSuccess(res));
  } catch (error) {}
}

function* sagaGlobalFetchFunctions(action: PayloadAction<IFilterBodyRequest>) {
  try {
    const res: IBasePaging<ILangViewModel> = yield call(
      functionApi.getAll,
      action.payload
    );
    console.log("sagaFetchFunctions", res);
    yield put(globalActions.fetchGlobalFunctionsSuccess(res));
  } catch (error) {}
}

export default function* categorySaga() {
  yield takeLatest(globalActions.fetchGlobalLangs, sagaGlobalFetchLangs);
  yield takeLatest(
    globalActions.fetchGlobalFunctions,
    sagaGlobalFetchFunctions
  );
}
