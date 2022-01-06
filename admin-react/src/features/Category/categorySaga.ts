import { PayloadAction } from "@reduxjs/toolkit";
import langApi from "api/langApi";
import { IBasePaging, ICategoryViewModel, IFilterBodyRequest, ILangViewModel } from "models";
import { call, put, takeLatest } from "redux-saga/effects";
import categoryApi from '../../api/categoryApi';
import { categoryActions } from './categorySlice';

function* fetchCategories(action: PayloadAction<IFilterBodyRequest>) {
  try {
    const res: IBasePaging<ICategoryViewModel> = yield call(categoryApi.getAll, action.payload);
    yield put(categoryActions.fetchCategoriesSuccess(res))
  } catch (error) {

  }
}

function* fetchLangs(action: PayloadAction<IFilterBodyRequest>) {
  try {
    const res: IBasePaging<ILangViewModel> = yield call(langApi.getAll, action.payload);
    yield put(categoryActions.fetchLangsSuccess(res))
  } catch (error) {

  }
}


export default function* categorySaga() {
  yield takeLatest(categoryActions.fetchCategories, fetchCategories)
  yield takeLatest(categoryActions.fetchLangs, fetchLangs)
}