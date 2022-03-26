import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RootState } from "app/store";
import { get, set } from "lodash";
import { IBaseLoading, IBasePaging, ICategoryAddOrUpdateModel, ICategoryDetailModel, ICategoryModel, IFilterBodyRequest, ILangViewModel, IPagination } from "models";
import { IKeyValue } from "models/Common/IKeyValue";

export interface ICategoryTable {
  data: ICategoryDetailModel[],
  pagination: IPagination,
}

export interface CategoryState {
  isLoading: boolean,
  table: IBaseLoading & ICategoryTable
  filterCategoryRequest: IFilterBodyRequest,
  langFilterRequest: IFilterBodyRequest,
  langs: ILangViewModel[],
  categoryAddOrUpdate: IBaseLoading & ICategoryAddOrUpdateModel,
}
const initialPagination: IPagination = {
  pageIndex: 1,
  pageSize: 5,
  pageCount: 0,
  totalRow: 0
}
const initialState: CategoryState = {
  isLoading: false,
  table: {
    isLoading: false,
    data: [],
    pagination: initialPagination,
  },
  filterCategoryRequest: {
    langId: "EN",
    pagination: initialPagination
  },
  langFilterRequest: {
    langId: "",
    pagination: initialPagination
  },
  langs: [],
  categoryAddOrUpdate: {
    isLoading: false,
    details: [
      {
        name: '',
        langId: 'vi',
        description: '',
      },
      {
        name: '',
        langId: 'en',
        description: '',
      }
    ],
  }
}

const categorySlice = createSlice({
  name: 'category',
  initialState,
  reducers: {
    fetchCategories(state, action: PayloadAction<IFilterBodyRequest>) {
      state.isLoading = true;
    },
    fetchCategoriesSuccess(state, action: PayloadAction<IBasePaging<ICategoryDetailModel>>) {
      state.table.data = action.payload.data;
      state.table.isLoading = false;
      state.table.pagination = action.payload.pagination;
      state.table.isLoading = false;
    },
    resetFilter(state) {
      state.filterCategoryRequest = {
        langId: "EN",
        pagination: initialPagination
      }
    },
    setFilter(state, action: PayloadAction<IKeyValue>) {
      if (get(state.filterCategoryRequest, action.payload.key) != action.payload.value) {
        set(state.filterCategoryRequest, action.payload.key, action.payload.value);
        state.table.isLoading = true;
      }
    },
    fetchLangs(state, action: PayloadAction<any>) {

    },
    fetchLangsSuccess(state, action: PayloadAction<IBasePaging<ILangViewModel>>) {
      state.langs = action.payload.data;
    },
    addOrUpdate(state, action: PayloadAction<ICategoryAddOrUpdateModel>) {
      state.categoryAddOrUpdate.isLoading = true;
    },
    addOrUpdateSuccess(state, action: PayloadAction<any>) {
      state.categoryAddOrUpdate.isLoading = false;
      state.filterCategoryRequest = {
        langId: "EN",
        pagination: initialPagination
      }
    },
    fetchCategoryUpdate(state, action: PayloadAction<number | undefined>) {
      // state.categoryAddOrUpdate = action.payload
      state.categoryAddOrUpdate.isLoading = true;
    },
    fetchCategoryUpdateSuccess(state, action: PayloadAction<ICategoryModel>) {
      state.categoryAddOrUpdate = { ...action.payload };
      state.categoryAddOrUpdate.isLoading = false;
    },
    fetchCategoryAdd(state) {
      state.categoryAddOrUpdate.isLoading = true;
      state.categoryAddOrUpdate = {
        isLoading: true,
        details: [
          {
            name: '',
            langId: 'vi',
            description: '',
          },
          {
            name: '',
            langId: 'en',
            description: '',
          }
        ],
      };
    },
    fetchCategoryAddSuccess(state, action: PayloadAction<any>) {
      state.categoryAddOrUpdate.isLoading = false;
    }
  }
})
// Actions
export const categoryActions = categorySlice.actions;

// Reducer
const categoryReducer = categorySlice.reducer;
export default categoryReducer;

// Selectors
export const selectCategoryTable = (state: RootState) => state.category.table;
export const selectLangs = (state: RootState) => state.category.langs;
export const selectCategoryTableLoading = (state: RootState) => state.category.isLoading;
export const selectCategoryTablePagination = (state: RootState) => state.category.table.pagination;
export const selectFilterCategoryRequest = (state: RootState) => state.category.filterCategoryRequest;
export const selectCategoryAddOrUpdate = (state: RootState) => state.category.categoryAddOrUpdate;
