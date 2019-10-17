import { Component, OnInit, Input } from '@angular/core';
import { Post, Item } from './post.model'
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'mt-post',
  templateUrl: './post.component.html',
  animations: [
    trigger('postAppered',[
      state('ready', style({ opacity: 1})),
      transition('void => ready', [
        style({opacity: 0, transform: 'translate(-30px, -10px)'}),
        animate('500ms 0s ease-in-out')
      ])
    ])
  ]
})
export class PostComponent implements OnInit {

  constructor() { }

  postState = 'ready';

  @Input() itemPost: Item;

  ngOnInit() {
  }

}
