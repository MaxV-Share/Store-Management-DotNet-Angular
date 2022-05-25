import { IBaseViewModel } from "../Bases/IBaseViewModel";
import { IFunctionDetailAddOrUpdateModel } from "../FunctionDetails/IFunctionDetailAddOrUpdateModel";
import { IFunctionModel } from "./IFunctionModel";

export interface IFunctionAddOrUpdateModel extends IBaseViewModel<string> {
  icon?: string;
  sortOrder?: number;
  url?: string;
  parentId?: string;
  parent?: IFunctionModel;
  details?: IFunctionDetailAddOrUpdateModel[];
}
