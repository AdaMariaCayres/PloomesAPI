# PloomesAPI
Endpoints:
    -Directors: /api/Director
        -GET:/{id}; /all
        -PUT:/{id}
        -DELETE:/{id}
        -POST body:
            {
            "id": 0,
            "name": "string",
            "birthday": "2024-06-23T02:11:32.866Z",
            "deathday": "2024-06-23T02:11:32.866Z"
            }
        
    -Movie:/api/Movie
        -GET:/{id}; /all
        -DELETE:/{id}
        -POST body:
            {
            "id": 0,
            "title": "string",
            "genre": "string",
            "description": "string",
            "year": 0,
            "language": "string",
            "directorId": 0
            
            }
Bugs conhecidos: 
1.POST em Movie exige corpo do objeto diretor, como evidenciado no swagger