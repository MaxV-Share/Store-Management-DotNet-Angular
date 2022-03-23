import { IBaseViewModel } from "models";
import { ICategoryDetailViewModel } from ".";

export interface ICategoryViewModel extends IBaseViewModel<number> {
  details?: ICategoryDetailViewModel[],
  parentId?: number
}
