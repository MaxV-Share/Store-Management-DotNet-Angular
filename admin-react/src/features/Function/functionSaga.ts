import { PayloadAction } from "@reduxjs/toolkit";
import { globalActions } from "app/globalSlice";
import {
  IBasePaging,
  IFilterBodyRequest,
  IFunctionFullModel,
  ILangViewModel,
} from "models";
import { call, put, takeLatest } from "redux-saga/effects";
import functionApi from "../../api/functionApi";
import { functionActions } from "./functionSlice";

function* fetchFunctions(action: PayloadAction<IFilterBodyRequest>) {
  try {
    const res: IBasePaging<IFunctionFullModel> = yield call(
      functionApi.getAll,
      action.payload
    );
    yield put(globalActions.fetchGlobalFunctionsSuccess(res));
    yield put(functionActions.fetchFunctionDataTableSuccess(res));
  } catch (error) {}
}

function* sagaFunctionAdd(action: PayloadAction<any>) {
  console.log("sagaAddOrUpdate", action.payload);
  try {
    const res: IBasePaging<ILangViewModel> = yield call(
      functionApi.add,
      action.payload
    );
    yield put(functionActions.addOrUpdateSuccess(res));
  } catch (error) {}
}

function* sagaFunctionUpdate(action: PayloadAction<any>) {
  console.log("sagaAddOrUpdate", action.payload);
  try {
    const res: IBasePaging<ILangViewModel> = yield call(
      functionApi.add,
      action.payload
    );
    yield put(functionActions.addOrUpdateSuccess(res));
  } catch (error) {}
}

function* fetchFunctionUpdate(action: PayloadAction<string>) {
  try {
    const res: IFunctionFullModel = yield call(
      functionApi.getById,
      action.payload
    );
    yield put(functionActions.fetchFunctionUpdateSuccess(res));
  } catch {}
}

function* fetchFunctionById(action: PayloadAction<string>) {
  try {
    const res: IFunctionFullModel = yield call(
      functionApi.getById,
      action.payload
    );
    yield put(functionActions.fetchFunctionUpdateSuccess(res));
  } catch {
    yield put(functionActions.fetchFunctionUpdateFailed());
  }
}

export default function* functionSaga() {
  yield takeLatest(functionActions.fetchFunctionDataTable, fetchFunctions);
  yield takeLatest(functionActions.fetchFunctionUpdate, fetchFunctionUpdate);
  yield takeLatest(functionActions.fetchFunctionById, fetchFunctionById);
  yield takeLatest(functionActions.add, sagaFunctionAdd);
  yield takeLatest(functionActions.update, sagaFunctionUpdate);
}
