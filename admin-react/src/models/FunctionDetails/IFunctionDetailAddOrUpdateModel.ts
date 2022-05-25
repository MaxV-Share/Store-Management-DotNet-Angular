import { IBaseViewModel } from "models/Bases";

export interface IFunctionDetailAddOrUpdateModel extends IBaseViewModel<number> {
  langId?: string,
  name?: string,
  functionId?: string,
}