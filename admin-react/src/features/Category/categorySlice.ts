import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RootState } from "app/store";
import { IBasePaging, ICategoryViewModel, IFilterBodyRequest, ILangViewModel, IPagination } from "models";

export interface CategoryState {
  loading: boolean,
  list: ICategoryViewModel[],
  pagination: IPagination,
  filterRequest: IFilterBodyRequest,
  langFilterRequest: IFilterBodyRequest,
  langs: ILangViewModel[]
}
const initialPagination: IPagination = {
  pageIndex: 1,
  pageSize: 15,
  pageCount: 0,
  totalRow: 0
}
const initialState: CategoryState = {
  loading: false,
  list: [],
  pagination: initialPagination,
  filterRequest: {
    langId: "EN",
    pagination: initialPagination
  },
  langFilterRequest: {
    langId: "",
    pagination: initialPagination
  },
  langs: []
}

const categorySlice = createSlice({
  name: 'category',
  initialState,
  reducers: {
    fetchCategories(state, action: PayloadAction<any>) {
      state.loading = true;
    },
    fetchCategoriesSuccess(state, action: PayloadAction<IBasePaging<ICategoryViewModel>>) {
      state.list = action.payload.data;
      state.pagination = action.payload.pagination;
      state.loading = false;
    },
    setFilter(state, action: PayloadAction<IFilterBodyRequest>) {
      state.filterRequest = action.payload
    },
    fetchLangs(state, action: PayloadAction<any>) {

    },
    fetchLangsSuccess(state, action: PayloadAction<IBasePaging<ILangViewModel>>) {
      state.langs = action.payload.data;
    }
  }
})
// Actions
export const categoryActions = categorySlice.actions;

// Reducer
const categoryReducer = categorySlice.reducer;
export default categoryReducer;

// Selectors
export const selectCategories = (state: RootState) => state.category.list;
export const selectLangs = (state: RootState) => state.category.langs;
export const selectCategoryLoading = (state: RootState) => state.category.loading;
export const selectCategoryPagination = (state: RootState) => state.category.pagination;
export const selectCategoryFilter = (state: RootState) => state.category.filterRequest;
