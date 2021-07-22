import { BaseViewModel ,BillDetail} from "@app/models";

export class Bill  extends BaseViewModel<number> {
    customerPhoneNumber?: string = null;
    customerFullName?: string = null;
    customerAddress?: string = null;
    userPaymentId?: string = null;
    userPaymentUserName?: string = null;
    totalPrice: number = null;
    discountPrice: number = null;
    paymentAmount?: number = null;
    billDetails: BillDetail[] = [];
}
