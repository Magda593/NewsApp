import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'author',
})
export class AuthorPipe implements PipeTransform {
  transform(name: String): String {
    return `By Author ${name}`;
  }
}
