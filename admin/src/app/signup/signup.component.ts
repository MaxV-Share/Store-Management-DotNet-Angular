import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../router.animations';
import { TranslateService } from '@ngx-translate/core';
import { Register } from '@app/models';

@Component({
    selector: 'app-signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.scss'],
    animations: [routerTransition()]
})
export class SignupComponent implements OnInit {
    register: Register;
    constructor(private translate: TranslateService) {}
    ngOnInit() {        
        this.translate.use(localStorage.getItem('lang') || navigator.language.substring(0,2));
    }
    onSubmit(e)
    {
        console.log(e);
        
    }
}
