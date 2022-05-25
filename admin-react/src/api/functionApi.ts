import { ToFormData } from "utils";
import { IBasePaging } from "../models/Bases/BasePaging";
import { IFilterBodyRequest } from "../models/Bases/IFilterBodyRequest";
import { IFunctionAddOrUpdateModel } from "../models/Functions/IFunctionAddOrUpdateModel";
import { IFunctionFullModel } from "../models/Functions/IFunctionFullModel";
import axiosClient from "./axiosClient";

const functionApi = {
  getAll(data: IFilterBodyRequest): Promise<IBasePaging<IFunctionFullModel>> {
    const url = "/functions/filter";
    return axiosClient().post(url, data);
  },
  getById(id: string): Promise<IFunctionFullModel> {
    const url = `/functions/${id}`;
    return axiosClient().get(url);
  },
  add(request: IFunctionAddOrUpdateModel): Promise<any> {
    var formRequest = new FormData();
    formRequest = ToFormData(request, formRequest);
    const url = "/functions";
    return axiosClient().post(url, formRequest);
  },
  update(request: IFunctionAddOrUpdateModel): Promise<any> {
    var formRequest = new FormData();
    formRequest = ToFormData(request, formRequest);
    const url = `/functions/${request.id}`;
    return axiosClient().put(url, formRequest);
  },
  remove(id: string): Promise<any> {
    const url = `/functions/${id}`;
    return axiosClient().delete(url);
  },
};

export default functionApi;
