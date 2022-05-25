import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { get, set } from "lodash";
import {
  IBasePaging,
  IFilterBodyRequest,
  IFunctionAddOrUpdateModel,
  IFunctionFullModel,
  ILangViewModel,
  IPagination,
} from "models";
import { IKeyValue } from "models/Common";

export interface IFunctionState {
  isLoading: boolean;
  table: any;
  filterFunctionRequest: IFilterBodyRequest;
  functionAddOrUpdateForm: any;
}
const initialPagination: IPagination = {
  pageIndex: 1,
  pageSize: 5,
  pageCount: 0,
  totalRow: 0,
};
const initialState: IFunctionState = {
  isLoading: false,
  table: {
    // isLoading: false,
    data: [],
    // pagination: initialPagination,
  },
  filterFunctionRequest: {
    langId: "EN",
    pagination: initialPagination,
  },
  functionAddOrUpdateForm: {
    data: {
      icon: "",
      id: "",
      url: "",
      details: [
        {
          name: "",
          langId: "vi",
        },
        {
          name: "",
          langId: "en",
        },
      ],
    },
    isLoading: false,
  },
};
const functionSlice = createSlice({
  name: "function",
  initialState,
  reducers: {
    fetchFunctionDataTable(state, action: PayloadAction<IFilterBodyRequest>) {
      state.isLoading = true;
    },
    fetchFunctionDataTableSuccess(
      state,
      action: PayloadAction<IBasePaging<IFunctionFullModel>>
    ) {
      state.table.data = action.payload.data;
      // state.table.isLoading = false;
      // state.table.pagination = action.payload.pagination;
    },
    resetFilter(state) {
      state.filterFunctionRequest = {
        langId: "EN",
        pagination: initialPagination,
      };
    },
    setFilter(state, action: PayloadAction<IKeyValue>) {
      if (
        get(state.filterFunctionRequest, action.payload.key) !=
        action.payload.value
      ) {
        set(
          state.filterFunctionRequest,
          action.payload.key,
          action.payload.value
        );
        // state.table.isLoading = true;
      }
    },
    fetchLangs(state, action: PayloadAction<any>) {},
    fetchLangsSuccess(
      state,
      action: PayloadAction<IBasePaging<ILangViewModel>>
    ) {
      //state.langs = action.payload.data;
    },
    add(state, action: PayloadAction<IFunctionAddOrUpdateModel>) {
      state.functionAddOrUpdateForm.isLoading = true;
    },
    update(state, action: PayloadAction<IFunctionAddOrUpdateModel>) {
      state.functionAddOrUpdateForm.isLoading = true;
    },
    addOrUpdateSuccess(state, action: PayloadAction<any>) {
      state.functionAddOrUpdateForm.isLoading = false;
      state.filterFunctionRequest = {
        langId: "EN",
        pagination: initialPagination,
      };
    },
    fetchFunctionUpdate(state, action: PayloadAction<string | undefined>) {
      // state.functionAddOrUpdateForm = action.payload
      state.functionAddOrUpdateForm.isLoading = true;
    },
    fetchFunctionById(state, action: PayloadAction<string | undefined>) {},
    fetchFunctionUpdateFailed(state) {},
    fetchFunctionUpdateSuccess(
      state,
      action: PayloadAction<IFunctionFullModel>
    ) {
      state.functionAddOrUpdateForm.data = { ...action.payload };
      state.functionAddOrUpdateForm.isLoading = false;
    },
    fetchFunctionAdd(state) {
      state.functionAddOrUpdateForm.isLoading = true;
      state.functionAddOrUpdateForm.data = {
        details: [
          {
            name: "",
            langId: "vi",
          },
          {
            name: "",
            langId: "en",
          },
        ],
      };
    },
    fetchFunctionAddSuccess(state, action: PayloadAction<any>) {
      state.functionAddOrUpdateForm.isLoading = false;
    },
  },
});
// Actions
export const functionActions = functionSlice.actions;

// Reducer
const functionReducer = functionSlice.reducer;
export default functionReducer;
