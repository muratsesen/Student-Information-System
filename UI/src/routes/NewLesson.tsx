import { useParams, Link, useNavigate } from "react-router-dom";
import { useEffect, useReducer } from "react";
import {
  useCreateLessonMutation,
  useUpdateLessonMutation,
  useLessonContentQuery
} from "../features/apiSlice";
import ToastNotify from "../components/ToastNotify";


const initialState = {
  id: 0,
  name: '',
  code: '',
  status: 1,
  credit: '',
};


const reducer = (state, action) => {
  switch (action.type) {
    case 'setValues':
      return { ...state, ...action.payload };
    default:
      return state;
  }
};

const NewLesson = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [createLesson, { isSuccess: lessonCreateSuccess }] = useCreateLessonMutation();
  const [updateLesson, { isSuccess: lessonUpdateSuccess }] = useUpdateLessonMutation();
  const [state, dispatch] = useReducer(reducer, initialState);
  const { data: lesson, isError, isLoading, isSuccess } = useLessonContentQuery({ id });

  useEffect(() => {
    if (isSuccess && lesson) {
      const userState = { ...lesson };
      dispatch({ type: 'setValues', payload: userState });
    }
  }, [isSuccess, lesson]);

  useEffect(() => {
    if (lessonCreateSuccess || lessonUpdateSuccess) {
      ToastNotify("DERS KAYDEDILDI!");
      navigate(-1);
    }

  }, [lessonCreateSuccess, lessonUpdateSuccess]);

  const handleChange = (e) => {
    const { name, value, checked } = e.target;

    if (name === 'status') {
      // Toggle the status between 1 and 0
      dispatch({ type: 'setValues', payload: { [name]: checked ? 1 : 0 } });
    } else {
      dispatch({ type: 'setValues', payload: { [name]: value } });
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Here you can submit the state data
    console.log('Submitted State:', state);
    if (id > 0) {
      updateLesson(state);
    }
    else {
      createLesson(state);
    }
  };


  return (
    <div
      class="block max-w-sm rounded-lg bg-white p-6 shadow-[0_2px_15px_-3px_rgba(0,0,0,0.07),0_10px_20px_-2px_rgba(0,0,0,0.04)] dark:bg-neutral-700">

      {id ? <h1> Ders Düzenle </h1> : <h1> Yeni Ders </h1>}
      <p className="text-blue-400 cursor-pointer" onClick={() => navigate(-1)}>
        Geri dön
      </p>
      <br />
      <form onSubmit={handleSubmit}>
        <div>
          <label>
            Ders Adı:
            <input
              type="text"
              name="name"
              placeholder="Ders Adı"
              value={state.name}
              onChange={handleChange}
            />
          </label>
        </div>
        <br />
        <div>
          <label>
            Ders Kodu:
            <input
              type="text"
              name="code"
              placeholder="Ders Kodu"
              value={state.code}
              onChange={handleChange}
            />
          </label>
        </div>
        <br />
        <div>
          <label>
            Kredi:
            <input
              type="number"
              name="credit"
              min="1"
              max={20}
              placeholder="Kredi"
              value={state.credit}
              onChange={handleChange}
            />
          </label>
        </div>
        <br />
        <div>
          {state.status === 1 ? (
            <label>
              <input
                type="checkbox"
                name="status"
                value={state.status}
                checked={state.status}
                onChange={handleChange}
              />
              Aktif
            </label>
          ) : (
            <label>
              <input
                type="checkbox"
                name="status"
                value={state.status}
                checked={state.status}
                onChange={handleChange}
              />
              Pasif
            </label>
          )}
        </div>

 
        <div class="relative mb-12" data-te-input-wrapper-init>
          <input
            type="email"
            class="peer block min-h-[auto] w-full rounded border-0 bg-transparent px-3 py-[0.32rem] leading-[1.6] outline-none transition-all duration-200 ease-linear focus:placeholder:opacity-100 data-[te-input-state-active]:placeholder:opacity-100 motion-reduce:transition-none dark:text-neutral-200 dark:placeholder:text-neutral-200 [&:not([data-te-input-placeholder-active])]:placeholder:opacity-0"
            id="exampleInputEmail1"
            aria-describedby="emailHelp"
            placeholder="Enter email" />
          <label
            for="exampleInputEmail1"
            class="pointer-events-none absolute left-3 top-0 mb-0 max-w-[90%] origin-[0_0] truncate pt-[0.37rem] leading-[1.6] text-neutral-500 transition-all duration-200 ease-out peer-focus:-translate-y-[0.9rem] peer-focus:scale-[0.8] peer-focus:text-primary peer-data-[te-input-state-active]:-translate-y-[0.9rem] peer-data-[te-input-state-active]:scale-[0.8] motion-reduce:transition-none dark:text-neutral-200 dark:peer-focus:text-primary"
          >Email address</label>
          
          <small
            id="emailHelp"
            class="absolute w-full text-neutral-500 dark:text-neutral-200"
            data-te-input-helper-ref
          >We'll never share your email with anyone else.</small>
          
        </div>


        <br />
        <br />
        <button type="submit">Kaydet</button>
      </form>

    </div>
  );
};

export default NewLesson;

