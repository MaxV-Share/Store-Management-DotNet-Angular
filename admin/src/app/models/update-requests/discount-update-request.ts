import { AutoMap } from "@automapper/classes"
import { BaseUpdateRequest } from ".."

export class DiscountUpdateRequest extends BaseUpdateRequest {
    @AutoMap()
    id?: number;
    @AutoMap()
    percentDiscount: number;
    @AutoMap()
    maxDiscountPrice: number;
    @AutoMap()
    fromDate: Date;
    @AutoMap()
    toDate: Date;
}
