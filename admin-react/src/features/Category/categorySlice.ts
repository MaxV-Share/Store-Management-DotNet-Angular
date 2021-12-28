import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RootState } from "app/store";
import { IBasePaging, ICategoryViewModel, IFilterBodyRequest, IPagination } from "models";

export interface CategoryState {
  loading: boolean,
  list: IBasePaging<ICategoryViewModel>,
  pagination: IPagination,
  filterRequest: IFilterBodyRequest
}
const initialPagination: IPagination = {
  pageIndex: 1,
  pageSize: 15,
  pageCount: 0,
  totalRow: 0
}
const initialState: CategoryState = {
  loading: false,
  list: {
    data: [],
    pagination: initialPagination
  },
  pagination: initialPagination,
  filterRequest: {
    langId: "EN",
    pagination: initialPagination
  }
}

const categorySlice = createSlice({
  name: 'category',
  initialState,
  reducers: {
    fetchCategories(state, action: PayloadAction<any>) {
      state.loading = true;
    },
    fetchCategoriesSuccess(state, action: PayloadAction<IBasePaging<ICategoryViewModel>>) {
      state.list = action.payload;
      state.pagination = action.payload.pagination;
      state.loading = false;
    },
    setFilter(state, action: PayloadAction<IFilterBodyRequest>) {
      state.filterRequest = action.payload
    }
  }
})
// Actions
export const categoryActions = categorySlice.actions;

// Reducer
const categoryReducer = categorySlice.reducer;
export default categoryReducer;

// Selectors
export const selectCategoryList = (state: RootState) => state.category.list;
export const selectCategoryLoading = (state: RootState) => state.category.loading;
export const selectCategoryPagination = (state: RootState) => state.category.pagination;
