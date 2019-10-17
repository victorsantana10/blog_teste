import { Observable } from "rxjs/Observable";
import { Response } from '@angular/http';

export class ErrorHandler{
    static handlerError(error : Response | any){
        let messageError: string;
        if(error instanceof Response)
            messageError = `Erro ${error.status} ao obter a URL ${error.url} - ${error.statusText}`;
        else
            messageError = error.toString();

        console.log(messageError);
        return Observable.throw(messageError);
    }
}