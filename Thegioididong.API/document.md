# System API Description

## Introduction

- API (Application Programming Interface) is a set of interfaces and procedures that an application or system provides to allow other applications to interact with it.

- In this article, we will describe the APIs of the system and define the endpoints as well as the methods supported by them.

## APIs

### Slide API

#### Get Slide Manage API

- Create Slide
- Endpoint: `/api/Slide/GetSlides`
- Method: POST
- Description: Get list slide paging
- Request body: 
```
{
    PageIndex: 1,
    PageSize: 2,
}
```
- Reponse body:
```
{
  "items": [
    {
      "id": 10,
      "name": "string",
      "page": "string",
      "position": "string",
      "published": false
    }
  ],
  "pageIndex": 1,
  "pageSize": 3,
  "totalRecords": 10,
  "totalPages": 4
}
```

#### Create Slide API

- Create Slide
- Endpoint: `/api/Slide/Create`
- Method: POST
- Description: Creates a new slide
- Request body: 
```
{
  "name": "HomeTop",
  "page": "home",
  "position": "top",
  "published": true,
  "slideItems": [
    {
      "title": "SlideHomeTop01",
      "image": "slide_home_top_01.png",
      "url": "/product/1"
    },
    {
      "title": "SlideHomeTop02",
      "image": "slide_home_top_02.png",
      "url": "/product/2"
    }
  ]
}
```
- Reponse body:
```
{
  "isSuccessed": true,
  "message": "Created successfully",
  "resultObj": null
}
```

#### Update Slide API

- Update Slide
- Endpoint: `/api/Slide/Update`
- Method: PUT
- Description: Update slide
- Request body: 
```
{
  "id": 9,
  "name": "slide 9",
  "page": "home",
  "position": "top",
  "published": true,
  "slideItems": [
    {
      "id": 29,
      "title": "slide item update 9",
      "image": "string",
      "url": "string"
    },
    {
      "title": "slide create 9",
      "image": "string",
      "url": "string"
    }
  ]
}
```
- Reponse body:
```
{
  "isSuccessed": true,
  "message": "Updated successfully",
  "resultObj": null
}
```

### ProductCategory API

#### Get Category Main Navigation API
- Get Category Main Navigation
- Endpoint: `/api/ProductCategory/GetCategoryMainNavigation`
- Method: GET
- Description: retrieves a list of product categories to display in the main-navigation section of the user interface, along with any child product groups associated with each category.
- Request body: The request body is empty.
- Reponse body:
```
[
    {
        "id": 10,
        "name": "Phụ kiện",
        "badgeIcon": null,
        "productCategoryGroups": [
            {
                "id": 1,
                "name": "Phụ kiện di động",
                "productCategories": [
                    {
                        "id": 20,
                        "name": "Túi đựng AirPods"
                    }
                ]
            }
        ],
        "productCategories": [
            {
                "id": 36,
                "name": "Máy tính để bàn"
            },
            {
                "id": 35,
                "name": "Màn hình máy tính"
            }
        ]
    }
]
```
