import { Base } from "./base.model"

export class Discount extends Base {
    percentDiscount: number
    maxDiscountPrice: number
    fromDate: Date
    toDate: Date

}
