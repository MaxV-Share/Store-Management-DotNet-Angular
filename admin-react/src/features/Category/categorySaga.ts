import { PayloadAction } from "@reduxjs/toolkit";
import { IBasePaging, ICategoryViewModel, IFilterBodyRequest } from "models";
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

export default function* categorySaga() {
  yield takeLatest(categoryActions.fetchCategories.type, fetchCategories)
}