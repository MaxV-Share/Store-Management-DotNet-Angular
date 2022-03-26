import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RootState } from "app/store";

export interface GlobalState {

}
const initialState: GlobalState = {

}

const globalSlice = createSlice({
  name: 'global',
  initialState,
  reducers: {
    fetchCategories(state, action: PayloadAction<any>) {
    },
  }
})
// Actions
export const categoryActions = globalSlice.actions;

// Reducer
const categoryReducer = globalSlice.reducer;
export default categoryReducer;

// Selectors
export const selectCategoryTable = (state: RootState) => state.category.table;
export const selectLangs = (state: RootState) => state.category.langs;
export const selectCategoryTableLoading = (state: RootState) => state.category.isLoading;
export const selectCategoryTablePagination = (state: RootState) => state.category.table.pagination;
export const selectFilterCategoryRequest = (state: RootState) => state.category.filterCategoryRequest;
export const selectCategoryAddOrUpdate = (state: RootState) => state.category.categoryAddOrUpdate;
