import { PayloadAction } from "@reduxjs/toolkit";
import { IBasePaging, ICategoryDetailModel, ICategoryModel, IFilterBodyRequest, ILangViewModel } from "models";
import { call, put, takeLatest } from "redux-saga/effects";
import categoryApi from '../../api/categoryApi';
import { categoryActions } from './categorySlice';

function* fetchCategories(action: PayloadAction<IFilterBodyRequest>) {
  try {
    const res: IBasePaging<ICategoryDetailModel> = yield call(categoryApi.getAll, action.payload);
    yield put(categoryActions.fetchCategoriesSuccess(res))
  } catch (error) {

  }
}

function* sagaAddOrUpdateCategory(action: PayloadAction<any>) {
  try {
    const res: IBasePaging<ILangViewModel> = yield call(categoryApi.addOrUpdate, action.payload);
    yield put(categoryActions.addOrUpdateCategorySuccess(res));
  } catch (error) {
    throw error;
  }
}

function* fetchCategoryUpdate(action: PayloadAction<number>) {
  try {
    const res: ICategoryModel = yield call(categoryApi.getById, action.payload);
    yield put(categoryActions.fetchCategoryUpdateSuccess(res));
  } catch {

  }
}

export default function* categorySaga() {
  yield takeLatest(categoryActions.fetchCategories, fetchCategories)
  yield takeLatest(categoryActions.fetchCategoryUpdate, fetchCategoryUpdate)
  yield takeLatest(categoryActions.addOrUpdateCategory, sagaAddOrUpdateCategory)
}