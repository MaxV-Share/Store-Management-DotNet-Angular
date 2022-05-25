import { createSelector } from "@reduxjs/toolkit";
import { RootState } from "app/store";

// Selectors
export const selectFunctionTable = createSelector(
  (state: RootState) => state.function.table,
  (table) => table
);
export const selectFunctionTableLoading = createSelector(
  (state: RootState) => state.function.table.isLoading,
  (loading) => loading
);
export const selectFunctionTablePagination = createSelector(
  (state: RootState) => state.function.table.pagination,
  (pagination) => pagination
);
export const selectFilterFunctionRequest = createSelector(
  (state: RootState) => state.function.filterFunctionRequest,
  (filterFunctionRequest) => filterFunctionRequest
);
export const selectFunctionAddOrUpdateData = createSelector(
  (state: RootState) => state.function.functionAddOrUpdateForm.data,
  (data) => data
);
export const selectFunctionAddOrUpdateFormLoading = createSelector(
  (state: RootState) => state.function.functionAddOrUpdateForm.isLoading,
  (loading) => loading
);
