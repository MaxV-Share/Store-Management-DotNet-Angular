import { createSelector } from "@reduxjs/toolkit";
import { IFunctionModel } from "models";
// import { arrayToTree } from "utils/array";
import { RootState } from "./store";

// Selectors
export const selectGlobalLangs = createSelector(
  (state: RootState) => state.global.langs,
  (langs) => langs
);

export const selectGlobalFullFunctions = createSelector(
  (state: RootState) => state.global.functions,
  (functions) => functions
);

export const selectGlobalCurrentLangCode = createSelector(
  (state: RootState) => state.global.langCode,
  (langCode) => langCode
);

export const selectGlobalFunctionsByCurrentLangCode = createSelector(
  (state: RootState) => state.global.functions,
  (state: RootState) => state.global.langCode,
  (functions, langCode) => {
    const result = functions.map<IFunctionModel>((f) => {
      const detail = f.details?.find((e) => e.langId == langCode);
      return {
        id: f.id,
        icon: f.icon,
        langId: detail?.langId,
        parentId: f.parentId,
        name: detail?.name,
        url: f.url,
        sortOrder: f.sortOrder,
      };
    });
    return result;
  }
);

export const selectGlobalFunctionTreeByCurrentLangCode = createSelector(
  (state: RootState) => state.global.functions,
  (state: RootState) => state.global.langCode,
  (functions, langCode) => {
    const result = functions.map<IFunctionModel>((f) => {
      const detail = f.details?.find((e) => e.langId == langCode);
      return {
        id: f.id,
        icon: f.icon,
        langId: detail?.langId,
        parentId: f.parentId,
        name: detail?.name,
        url: f.url,
        sortOrder: f.sortOrder,
      };
    });
    // return arrayToTree(result);
    return result;
  }
);
