import { IBaseViewModel } from "models";

export interface ICategoryViewModel extends IBaseViewModel<number> {
  categoryId: number,
  langId: string,
  name: string,
  description: string,
}