import { IBaseViewModel } from "models/Bases";
import { ICategoryDetailAddOrUpdateModel } from "models/CategoryDetails";

export interface ICategoryAddOrUpdateModel extends IBaseViewModel<number> {
  details?: ICategoryDetailAddOrUpdateModel[],
  parentId?: number
}
