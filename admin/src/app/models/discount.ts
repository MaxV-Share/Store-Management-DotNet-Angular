import { Base } from "./bases/base"

export class Discount extends Base {
    percentDiscount: number
    maxDiscountPrice: number
    fromDate: Date
    toDate: Date

}
