import { IBaseViewModel } from "models";

export interface ILangViewModel extends IBaseViewModel<string> {
  name?: string;
  order?: number;
}