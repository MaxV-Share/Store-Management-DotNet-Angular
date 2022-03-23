import { PayloadAction } from '@reduxjs/toolkit';
import studentApi from 'api/studentApi';
import { Student } from 'models';
import { IListParams, ListResponse } from 'models/Common';
import { call, debounce, put, takeLatest } from 'redux-saga/effects';
import { studentActions } from './studentSlice';

function* fetchStudentList(action: PayloadAction<IListParams>) {
  try {
    const response: ListResponse<Student> = yield call(studentApi.getAll, action.payload);
    yield put(studentActions.fetchStudentListSuccess(response));
  } catch (error) {
    console.log('Failed to fetch student list', error);
    yield put(studentActions.fetchStudentListFailed());
  }
}
function* handleSearchDebounce(action: PayloadAction<IListParams>) {
  yield put(studentActions.setFilter(action.payload));
}

export default function* studentSaga() {
  yield takeLatest(studentActions.fetchStudentList.type, fetchStudentList);

  yield debounce(500, studentActions.setFilterWithDebounce.type, handleSearchDebounce);
}
