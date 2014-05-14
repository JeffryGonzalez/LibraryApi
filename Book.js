// JavaScript source code
var bookAvailableForLoan = {
	"id": 1,
	"title": "Walden",
	"author": "Thoreau",
	"links": {
		"http://bookstore.com/rel#loans": {
			"href-template": "/loans/{bookId}/{friendId}{?action}",
			"href-vars": {
				"bookId": 1,
				"friendId": null,
				"action": "borrow"
			},
			"hints": {
				"allow": [
					"POST"
				]
			}
		}
	}
};

var bookAlreadyLoaned = {
	"id": 1,
	"title": "Walden",
	"author": "Thoreau",
	"dateLoaned": "2014-05-14T10:27:13.392Z",
	"links": {
		"http://bookstore.com/rel#friends": {
			"href-template": "/friends/{friendId}",
			"href-vars": {
				"friendId": 2
			},
			"hints": {
				"allow": [
					"GET"
				]
			}
		},
		"http://bookstore.com/rel#loans": {
			"href-template": "/loans/{bookId}/{friendId}{?action}",
			"href-vars": {
				"bookId": 1,
				"friendId": 2,
				"action": "return"
			},
			"hints": {
				"allow": [
					"POST"
				]
			}
		}
	}
}