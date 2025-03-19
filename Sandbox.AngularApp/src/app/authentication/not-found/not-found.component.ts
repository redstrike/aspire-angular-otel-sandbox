import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
	selector: 'app-not-found',
	template: `
		<h1>Not Found</h1>
		<p>Sorry, the page you are looking for cannot be found.</p>
		<p>Go back to the <a routerLink="/">home page</a>.</p>
	`,
	imports: [RouterLink],
	changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class NotFoundComponent {}
