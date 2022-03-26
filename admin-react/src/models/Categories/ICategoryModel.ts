import { ICategoryDetailModel } from "models/CategoryDetails";
import { ICategoryAddOrUpdateModel } from './ICategoryAddOrUpdateModel';

export interface ICategoryModel extends ICategoryAddOrUpdateModel {
  details?: ICategoryDetailModel[],
  parentId?: number
}
