import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const baseUrl = "https://localhost:7277/"
//TODO:centerilize token
function getToken() {
    let token = localStorage.getItem('token');
    if (token) {
        return token;
    }
}

const baseQuery = fetchBaseQuery({
    baseUrl: baseUrl,
    prepareHeaders: (headers, { getState }) => {
        // const token = getState().auth.token
        const token = getToken();

        // If we have a token set in state, let's assume that we should be passing it.
        if (token) {
            headers.set('Authorization', `Bearer ${token}`)
        }
        return headers
    },
})

export const apiSlice = createApi({
    reducerPath: 'api',
    baseQuery: baseQuery,
    tagTypes: [],
    refetchOnMountOrArgChange: true,
    endpoints: builder => ({
        registeredLessons:builder.query({
            query:(data)=>({
                url:`ogrenci/kayitolunan-dersler/${data.id}`,
                method:"get",
            })
        }),
        paths: builder.query({
            query: (data) => ({
                url: '/learningpaths',
                method: "get",
            })
        }),
        practice: builder.query({
            query: (data) => ({
                url: `/learningpaths/${data.id}/practices/`,
                method: "get",
            })
        }),
        lesson: builder.query({
            query: ({id}) => ({
                url: `courses/lessons/${id}/`,
                method: "get",
            })
        }),
        courses: builder.query({
            query: (data) => ({
                url: '/courses',
                method: "get",
            }),
            providesTags: ['course'],
        }),
        singleCourse: builder.query({
            query: (data) => ({
                url: `/courses/${data.id}`,
                method: "get",
            }),
            providesTags: ['course'],
        }),
        createCourse: builder.mutation({
            query: ({ title, technology, description, order_number, status, level }) => ({
                url: `courses/`,
                method: "post",
                body: { title, technology, description, order_number, status, level }
            }),
            invalidatesTags: ['course'],
        }),
        updateCourse: builder.mutation({
            query: ({ id, title, technology, description, order_number, status, level, chapters, points, labels }) => ({
                url: `courses/${id}/`,
                method: "put",
                body: { id, title, technology, description, order_number, status, level, chapters, points, labels }
            }),
            invalidatesTags: ['course'],
        }),
        deleteCourse: builder.mutation({
            query: (id) => ({
                url: `courses/${id}/`,
                method: "delete",
            }),
            invalidatesTags: ['course'],
        }),
        games: builder.query({
            query: (data) => ({
                url: '/games',
                method: "get",
            })
        }),
        gamesWithSection: builder.query({
            query: (data) => ({
                url: `/games/${data.id}/sections`,
                method: "get",
            })
        }),
        gameStepsWithSection: builder.query({
            query: (data) => ({
                url: `/games/${data.id}/sections/${data.sectionId}/steps`,
                method: "get",
            })
        }),
        gameStepWithSectionId: builder.query({
            query: (data) => ({
                url: `/games/${data.gameId}/sections/${data.sectionId}/steps/${data.stepId}`,
                method: "get",
            })
        }),
        gameStepsWithoutSection: builder.query({
            query: (data) => ({
                url: `/games/${data.id}/sections/steps`,
                method: "get",
            })
        }),
        gameStepWithoutSectionId: builder.query({
            query: (data) => ({
                url: `/games/${data.gameId}/sections/steps/${data.stepId}`,
                method: "get",
            })
        }),
        leaderBoards: builder.query({
            query: (data) => ({
                url: 'leaderboards/totalpoints/',
                method: "get",
            })
        }),
        user: builder.query({
            query: (data) => ({
                url: `users/${data.userId}`,
                method: "get",
            }),
            providesTags: ['userProfil'],
        }),
        updateProfil: builder.mutation({
            query: ({ id, first_name, last_name, username, user_avatar, school, birth_date }) => ({
                url: `auth/update_profile/${id}/`,
                method: "put",
                body: { id, first_name, last_name, username, user_avatar, school, birth_date }
            }),
            invalidatesTags: ['userProfil'],
        }),
        activeDays: builder.query({
            query: (data) => ({
                url: 'useractivies/activedays/month/',
                method: "get",
            })
        }),
        activeDaysDate: builder.query({
            query: (data) => ({
                url: 'useractivies/activedays/',
                method: "get",
            })
        }),
        followingLessons: builder.query({
            query: () => ({
                url: 'useractivies/lessons_followed/',
                method: "get",
            })
        }),
        userActivitiesInLastDays: builder.query({
            query: () => ({
                url: 'useractivies/in_last_days/',
                method: "get",
            })
        }),
        dailyAdvice: builder.query({
            query: (data) => ({
                url: 'daily_advice/',
                method: "get",
            })
        }),
        addDailyAdvice: builder.mutation({
            query: (title) => ({
                url: 'daily_advice/',
                method: "post",
                body: { title },
            })
        }),
        allUserLessonActivities: builder.query({
            query: () => ({
                url: 'useractivies/lessons/',
                method: "get",
            }),
            providesTags: ['videos'],
        }),
        addUserLessonActivities: builder.mutation({
            query: (lesson) => ({
                url: 'useractivies/lessons/',
                method: "post",
                body: { lesson },
            }),
            invalidatesTags: ['videos'],
        }),
        removeUserLessonActivite: builder.mutation({
            query: (lesson) => ({
                url: `useractivies/lessons/${lesson}`,
                method: "delete",
                body: { lesson },
            }),
            invalidatesTags: ['videos'],
        }),
        userSertificates: builder.query({
            query: () => ({
                url: 'awards/certificates/',
                method: "get",
            }),
        }),
        userBadges: builder.query({
            query: () => ({
                url: 'awards/badges/',
                method: "get",
            }),
        }),
        clearCache: builder.mutation({
            query: () => ({
                url: 'system_dashboard/cahce/flush/',
                method: "delete",
            }),
        }),
        users: builder.query({
            query: () => ({
                url: 'users/',
                method: "get",
            }),
            providesTags: ['user'],
        }),
        getUser: builder.query({
            query: (id) => ({
                url: `users/${id}/`,
                method: "get",
            }),
        }),
        createUser: builder.mutation({
            query: ({ first_name, last_name, email, subscription_type, subscription_period, role, telNumber }) => ({
                url: `users/`,
                method: "post",
                body: { first_name, last_name, email, subscription_type, subscription_period, role, telNumber }
            }),
            invalidatesTags: ['user'],
        }),
        updateUser: builder.mutation({
            query: ({ id, first_name, last_name, email, subscription_type, subscription_period, role, telNumber }) => ({
                url: `users/${id}/`,
                method: "put",
                body: { id, first_name, last_name, email, subscription_type, subscription_period, role, telNumber }
            }),
            invalidatesTags: ['user'],
        }),
        deleteUser: builder.mutation({
            query: (id) => ({
                url: `users/${id}/`,
                method: "delete",
            }),
            invalidatesTags: ['user'],
        }),
        getUserSubscriptionType: builder.query({
            query: () => ({
                url: `users/subscription_type/`,
                method: "get",
            }),
        }),
        getTotalStudent: builder.query({
            query: () => ({
                url: `classes/total/`,
                method: "get",
            }),
        }),
        joinToClass: builder.mutation({
            query: (class_code) => ({
                url: `classes/student/join/`,
                method: "post",
                body: { class_code }
            }),
        }),
        getStudentSubscribedClasses: builder.query({
            query: () => ({
                url: `classes/students/`,
                method: "get",
            }),
        }),
        getStudentHomework: builder.query({
            query: (id) => ({
                url: `classes/students/homeworks/${id}/`,
                method: "get",
            }),
        }),
        trails: builder.query({
            query: () => ({
                url: '/trails',
                method: "get",
            }),
            providesTags: ['trail'],
        }),
        singleTrail: builder.query({
            query: (data) => ({
                url: `/trails/${data.id}`,
                method: "get",
            }),
            providesTags: ['trail'],
        }),
        createTrail: builder.mutation({
            query: ({ title, description, order_number, status, courses }) => ({
                url: `trails/`,
                method: "post",
                body: { title, description, order_number, status, courses  }
            }),
            invalidatesTags: ['trail'],
        }),
        updateTrail: builder.mutation({
            query: ({ id, title, description, order_number, status, courses}) => ({
                url: `trails/${id}/`,
                method: "put",
                body: { id, title, description, order_number, status, courses}
            }),
            invalidatesTags: ['trail'],
        }),
        deleteTrail: builder.mutation({
            query: (id) => ({
                url: `trails/${id}/`,
                method: "delete",
            }),
            invalidatesTags: ['trail'],
        }),
    })
})

export const { 
    useRegisteredLessonsQuery
  
    } = apiSlice;

