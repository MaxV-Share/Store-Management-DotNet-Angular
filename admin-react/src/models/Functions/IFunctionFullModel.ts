import { IFunctionDetailModel } from "../FunctionDetails";
import { IFunctionAddOrUpdateModel } from "./IFunctionAddOrUpdateModel";

export interface IFunctionFullModel extends IFunctionAddOrUpdateModel {
  details?: IFunctionDetailModel[];
}
