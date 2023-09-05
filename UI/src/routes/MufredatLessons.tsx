import React, { useEffect } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { fetchAllUsers } from "../features/user/userSlice";
import { Button, Table } from "@mantine/core";
import {useMufredatDerslerQuery,useRegisterLessonsMutation,useRegisteredLessonsQuery} from "../features/apiSlice"
import ToastNotify from "../components/ToastNotify";


const MufredatLessons = () => {
  const  id  = localStorage.getItem("mufredatId");
  let ogrenciId = localStorage.getItem("ogrenciId");

  const navigate = useNavigate();
 
  const { data: refisteredLessons } = useRegisteredLessonsQuery({id:ogrenciId});
  const { data: lessons, isError ,isLoading } = useMufredatDerslerQuery({id});
  const [registerLesson,{isSuccess}] = useRegisterLessonsMutation();

  useEffect(() => {
    if (isSuccess) {
      ToastNotify("DERS KAYDEDILDI!");
    }
  },[isSuccess]);

 let registeredLessonIds = refisteredLessons?.length > 0 ? refisteredLessons?.map((lesson) => (lesson.id)):[];
  console.log(registeredLessonIds);

  const data =lessons?.length > 0 ? lessons?.map((lesson) => (
    <tr key={lesson.id}>
      <td>{lesson.id}</td>
      <td>{lesson.name}</td>
      <td>
        {
          registeredLessonIds.includes(lesson.id) ? <span style={{color:"green"}}>Kayıtlı</span> :
          <Button onClick={() => registerLesson({ogrenciId,dersId:lesson.id})}>Kaydol</Button>
        }
      </td>
    </tr>
  )): (<tr> <td colSpan={2}>Henüz ders kaydı yok</td> </tr>);

  return (
    <div>
      <span className="text-blue-400 cursor-pointer"
        onClick={() => navigate(-1)}>
        Geri Dön
      </span>
      {isLoading ? (
        <h1>Fetching...</h1>
      ) : isError ? (
        Error
      ) : (
        <Table striped highlightOnHover withBorder withColumnBorders>
          <thead>
            <tr>
              <th>ID</th>
              <th>Ders Adı</th>
              <th>Kayıt Durumu</th>
            </tr>
          </thead>
          <tbody>{data}</tbody>
        </Table>
      )}
    </div>
  );
};

export default MufredatLessons;
