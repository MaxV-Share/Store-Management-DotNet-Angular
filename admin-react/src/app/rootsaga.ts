import langApi from 'api/langApi';
import categorySaga from 'features/Category/categorySaga';
import { categoryActions } from 'features/Category/categorySlice';
import citySaga from 'features/city/citySaga';
import dashboardSaga from 'features/dashboard/dashboardSaga';
import studentSaga from 'features/student/studentSaga';
import { IBasePaging, IFilterBodyRequest, ILangViewModel } from 'models';
import { all, call, put } from 'redux-saga/effects';
import authSaga from '../features/auth/authSaga';


function* helloSaga() {
  console.log('hello saga');
}
function* fetchLangs() {
  const payload: IFilterBodyRequest = {
    langId: "",
    pagination: {
      pageIndex: 1,
      pageSize: 999
    },
    orders: [{ field: 'order', direction: 'asc' }]
  }
  try {
    const res: IBasePaging<ILangViewModel> = yield call(langApi.getAll, payload);
    yield put(categoryActions.fetchLangsSuccess(res))
  } catch (error) {

  }
}

export default function* rootSaga() {
  yield all([
    fetchLangs(),
    authSaga(),
    dashboardSaga(),
    studentSaga(),
    categorySaga(),
    citySaga(),
  ])
}