 export interface Post {
    channel: Channel;
  }
  
  interface Channel {
    item: Item[];
    title: string;
    atomLink: string;
    link: string;
    description: string;
    lastBuildDate: string;
    lastBuildDateFormatted: string;
    language: string;
    syUpdatePeriod: string;
    syUpdateFrequency: number;
    generator: string;
  }
  
 export interface Item {
    countMostRelevantWords: CountMostRelevantWord[];
    title: string;
    link: string;
    comments: string;
    pubDate: string;
    pubDateFormatted: string;
    dcCreator: string;
    category: string;
    guid: string;
    description: string;
    contentEncoded: string;
    slashComments: string;
    wfwCommentRss: string;
    totalWord: number;
  }
  
  interface CountMostRelevantWord {
    word: string;
    count: number;
  }