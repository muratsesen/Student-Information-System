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
        lessons: builder.query({
            query: (data) => ({
                url: `ders/dersler`,
                method: "get",
            })
        }),
        lessonContent: builder.query({
            query: (data) => ({
                url: `ders/ders/${data.id}`,
                method: "get",
            })
        }),
        createLesson: builder.mutation({
            query: (data) => ({
                url: `ders/yeni`,
                method: "post",
                body:data
            })
        }),
        updateLesson: builder.mutation({
            query: (data) => ({
                url: `ders/degistir`,
                method: "put",
                body:data
            })
        }),
        registeredLessons: builder.query({
            query: (data) => ({
                url: `ogrenci/kayitolunan-dersler/${data.id}`,
                method: "get",
            })
        }),
        registerLessons: builder.mutation({
            query: (data) => ({
                url: `derskayit/kayit`,
                method: "post",
                body:data
            })
        }),
        students: builder.query({
            query: (data) => ({
                url: `ogrenci/ogrenciler`,
                method: "get",
            })
        }),
        studentDetails: builder.query({
            query: (data) => ({
                url: `ogrenci/ogrenci/${data.id}`,
                method: "get",
            })
        }),
        createStudent: builder.mutation({
            query: (data) => ({
                url: `ogrenci/yeni`,
                method: "post",
                body:data
            })
        }),
        updateStudent: builder.mutation({
            query: (data) => ({
                url: `ogrenci/degistir`,
                method: "put",
                body:data
            })
        }),
        mufredatlar: builder.query({
            query: () => ({
                url: `mufredat/mufredatlar`,
                method: "get"
            })
        }),
        mufredatDersler: builder.query({
            query: (data) => ({
                url: `mufredat/dersler/${data.id}`,
                method: "get"
            })
        }),
        mufredat: builder.query({
            query: (data) => ({
                url: `mufredat/mufredat/${data.id}`,
                method: "get"
            })
        }),
        createMufredat: builder.mutation({
            query: (data) => ({
                url: `mufredat/yeni`,
                method: "post",
                body:data
            })
        }),
        updateMufredat: builder.mutation({
            query: (data) => ({
                url: `mufredat/degistir`,
                method: "put",
                body:data
            })
        }),
        users: builder.query({
            query: (data) => ({
                url: `users`,
                method: "get",
            })
        }),
        userDetails: builder.query({
            query: (data) => ({
                url: `users/${data.id}`,
                method: "get",
            })
        }),
        createUser: builder.mutation({
            query: (data) => ({
                url: `users`,
                method: "post",
                body:data
            })
        }),
        updateUser: builder.mutation({
            query: (data) => ({
                url: `users`,
                method: "put",
                body:data
            })
        }),
        deleteUser: builder.mutation({
            query: (data) => ({
                url: `users`,
                method: "delete",
                body:data
            })
        }),
        profile: builder.query({
            query: () => ({
                url: `auth/info`,
                method: "get",
            })
        }),

        
    })
})

export const {
    useLessonsQuery,
    useLessonContentQuery,
    useCreateLessonMutation,
    useUpdateLessonMutation,
    useRegisteredLessonsQuery,
    useRegisterLessonsMutation,
    useStudentsQuery,
    useStudentDetailsQuery,
    useCreateStudentMutation,
    useMufredatlarQuery,
    useUpdateStudentMutation,
    useMufredatDerslerQuery,
    useMufredatQuery,
    useCreateMufredatMutation,
    useUpdateMufredatMutation,
    useUsersQuery,
    useUserDetailsQuery,
    useCreateUserMutation,
    useUpdateUserMutation,
    useDeleteUserMutation,
    useProfileQuery

} = apiSlice;

