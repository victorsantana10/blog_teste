import { Component, OnInit, Input } from '@angular/core';
import { PostsServices } from './posts.services';
import { Post } from './post/post.model';

@Component({
  selector: 'mt-posts',
  templateUrl: './posts.component.html'
})

export class PostsComponent implements OnInit {

  post: Post;

  constructor(private postsServices: PostsServices) { }
  
  ngOnInit() {
    this.postsServices.GetPosts()
      .subscribe(post => this.post = post)
  }

}
