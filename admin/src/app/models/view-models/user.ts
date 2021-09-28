import { BaseViewModel } from '@app/models/bases';
import { AutoMap } from '@automapper/classes';
export class User extends BaseViewModel {
    @AutoMap()
    id?: number;
    @AutoMap()
    userName: string;
}
