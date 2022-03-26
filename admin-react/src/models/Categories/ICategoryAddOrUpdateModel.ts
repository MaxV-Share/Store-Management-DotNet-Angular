import { IBaseViewModel } from "models/Bases";
import { ICategoryDetailAddOrUpdateModel } from "models/CategoryDetails";

export interface ICategoryAddOrUpdateModel extends IBaseViewModel<number> {
  isLoading?: boolean,
  details?: ICategoryDetailAddOrUpdateModel[],
  parentId?: number
}
