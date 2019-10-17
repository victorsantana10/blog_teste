import { Injectable } from '@angular/core'
import { Http} from '@angular/http'
import { Post } from "./post/post.model"
import { MEAT_API } from '../app.api'
import { Observable } from 'rxjs/Observable'
import { ErrorHandler } from '../errorHandler'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class PostsServices{

      constructor(private http: Http){}

      GetPosts(): Observable<Post>{
        return this.http.get(`${MEAT_API}/api/BlogMinutoSeguro`)
          .map(response => response.json())
          .catch(ErrorHandler.handlerError);
      }
} 