import langApi from "api/langApi";
import categorySaga from "features/Category/categorySaga";
import citySaga from "features/city/citySaga";
import dashboardSaga from "features/dashboard/dashboardSaga";
import functionSaga from "features/Function/functionSaga";
// import studentSaga from "features/Student/studentSaga";
import {
  IBasePaging,
  IFilterBodyRequest,
  IFunctionFullModel,
  ILangViewModel,
} from "models";
import { all, call, put } from "redux-saga/effects";
import functionApi from "../api/functionApi";
import authSaga from "../features/auth/authSaga";
import { globalActions } from "./globalSlice";

function* fetchLangs() {
  const payload: IFilterBodyRequest = {
    langId: "",
    pagination: {
      pageIndex: 1,
      pageSize: 999,
    },
    orders: [{ field: "order", direction: "asc" }],
  };
  try {
    const res: IBasePaging<ILangViewModel> = yield call(
      langApi.getAll,
      payload
    );
    yield put(globalActions.fetchGlobalLangsSuccess(res));
  } catch (error) {}
}

function* fetchFunctions() {
  const payload: IFilterBodyRequest = {
    langId: "",
    pagination: {
      pageIndex: 1,
      pageSize: 999,
    },
    orders: [],
  };
  try {
    const res: IBasePaging<IFunctionFullModel> = yield call(
      functionApi.getAll,
      payload
    );
    yield put(globalActions.fetchGlobalFunctionsSuccess(res));
  } catch (error) {}
}

export default function* rootSaga() {
  yield all([
    fetchLangs(),
    fetchFunctions(),
    authSaga(),
    dashboardSaga(),
    // studentSaga(),
    categorySaga(),
    functionSaga(),
    citySaga(),
  ]);
}
