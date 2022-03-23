import { PayloadAction } from "@reduxjs/toolkit";
import langApi from "api/langApi";
import { IBasePaging, ICategoryDetailViewModel, ICategoryViewModel, IFilterBodyRequest, ILangViewModel } from "models";
import { call, put, takeLatest } from "redux-saga/effects";
import categoryApi from '../../api/categoryApi';
import { categoryActions } from './categorySlice';

function* fetchCategories(action: PayloadAction<IFilterBodyRequest>) {
  try {
    const res: IBasePaging<ICategoryDetailViewModel> = yield call(categoryApi.getAll, action.payload);
    yield put(categoryActions.fetchCategoriesSuccess(res))
  } catch (error) {

  }
}

function* sagaFetchLangs(action: PayloadAction<IFilterBodyRequest>) {
  try {

    const res: IBasePaging<ILangViewModel> = yield call(langApi.getAll, action.payload);
    yield put(categoryActions.fetchLangsSuccess(res))
  } catch (error) {

  }
}

function* sagaAddOrUpdate(action: PayloadAction<any>) {
  try {
    const res: IBasePaging<ILangViewModel> = yield call(categoryApi.addOrUpdate, action.payload);
    yield put(categoryActions.addOrUpdateSuccess(res));
  } catch (error) {

  }
}

function* fetchCategoryUpdate(action: PayloadAction<number>) {
  try {
    const res: ICategoryViewModel = yield call(categoryApi.getById, action.payload);
    yield put(categoryActions.fetchCategoryUpdateSuccess(res));
  } catch {

  }
}

export default function* categorySaga() {
  yield takeLatest(categoryActions.fetchCategories, fetchCategories)
  yield takeLatest(categoryActions.fetchLangs, sagaFetchLangs)
  yield takeLatest(categoryActions.fetchCategoryUpdate, fetchCategoryUpdate)
  yield takeLatest(categoryActions.addOrUpdate, sagaAddOrUpdate)
}