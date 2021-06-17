import { Base } from "./base";

export class Bill  extends Base {
    customerPhoneNumber : string;
    userPaymentId : string;
    UserPaymentUserName : string;
    totalPrice : number;
    discountPrice : number;
}
