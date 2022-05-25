import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import {
  IBasePaging,
  IFilterBodyRequest,
  IFunctionFullModel,
  ILangViewModel,
} from "models";

export interface GlobalState {
  isLoading?: boolean;
  langs: ILangViewModel[];
  functions: IFunctionFullModel[];
  langCode: string;
}

const initialState: GlobalState = {
  isLoading: true,
  langs: [],
  functions: [],
  langCode: "vi",
};

const globalSlice = createSlice({
  name: "global",
  initialState,
  reducers: {
    setCurrentLangCode(state, action: PayloadAction<string>) {
      state.langCode = action.payload;
    },
    fetchGlobalLangs(state, action: PayloadAction<IFilterBodyRequest>) {},
    fetchGlobalLangsSuccess(
      state,
      action: PayloadAction<IBasePaging<ILangViewModel>>
    ) {
      state.langs = action.payload.data;
    },
    fetchGlobalFunctions(state, action: PayloadAction<IFilterBodyRequest>) {},
    fetchGlobalFunctionsSuccess(
      state,
      action: PayloadAction<IBasePaging<IFunctionFullModel>>
    ) {
      state.functions = action.payload.data;
      console.log("fetchGlobalFunctionsSuccess", state.functions);
    },
  },
});

// Actions
export const globalActions = globalSlice.actions;

// Reducer
const globalReducer = globalSlice.reducer;
export default globalReducer;
