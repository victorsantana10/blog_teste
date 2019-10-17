import { Routes } from '@angular/router'
import { HomeComponent } from 'app/home/home.component'
import { PostsComponent } from 'app/posts/posts.component'
import { NotFoundComponent } from './not-found/not-found.component';

export const ROUTES: Routes = [
    { path: '', component: HomeComponent },
    { path: 'posts', component: PostsComponent },
    { path: '**', component: NotFoundComponent }
]