var doc = {
	resources: {
		"http://bookstore.com/rel#book": {
			"href-template": "/book/{id}",
			"href-vars": {
				"id": null
			},
			"hints": {
				"allow": [
					"GET"
				],
				"formats": {
					"application/json": {},
					"application/vnd.book+json": {}
				}
			}
		},
		"http://bookstore.com/rel#books": {
			"href": "/books",
			"hints": {
				"allow": [
					"GET"
				]
			},
			"formats": {
				"application/json": {},
				"application/vnd.collection+json": {}
			}
		},
		"http://bookstore.com/rel#loans": {
			"href-template": "/loans/{bookId}/{friendId}{?action}",
			"href-vars": {
				"bookId": null,
				"friendId": null,
				"action": null
			},
			"hints": {
				"allow": [
          "POST"
				]
			}
		}

	}



}