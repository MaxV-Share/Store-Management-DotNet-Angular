import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ENVIRONMENT } from '@app/models';
import { throwError } from 'rxjs';

export abstract class BaseService {

    public _sharedHeaders = new HttpHeaders();
    constructor(public http: HttpClient) {
        this._sharedHeaders = ENVIRONMENT._sharedHeaders;
    }

    protected handleError(error: any) {

        const applicationError = error.headers.get('Application-Error');

        // either application-error in header or model error in body
        if (applicationError) {
            return throwError(applicationError);
        }

        let modelStateErrors = '';

        // for now just concatenate the error descriptions, alternative we could simply pass the entire error response upstream
        for (const key in error.error) {
            if (error.error[key]) { modelStateErrors += error.error[key].description + '\n'; }
        }

        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
        return throwError(modelStateErrors || 'Server error');
    }
}
