import { BaseViewModel } from "@app/models";

export class Discount extends BaseViewModel<number> {
    percentDiscount: number
    maxDiscountPrice: number
    fromDate: Date
    toDate: Date

}
