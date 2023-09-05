import React, { useEffect } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { fetchAllUsers } from "../features/user/userSlice";
import { Button, Table } from "@mantine/core";
import {useMufredatDerslerQuery,useRegisterLessonsMutation} from "../features/apiSlice"


const MufredatLessons = () => {
  const  id  = localStorage.getItem("mufredatId");
  let ogrenciId = localStorage.getItem("ogrenciId");

  const navigate = useNavigate();
 
  const { data: lessons, isError ,isLoading } = useMufredatDerslerQuery({id});
  const [registerLesson,{isSuccess}] = useRegisterLessonsMutation();

  const data =lessons?.length > 0 ? lessons?.map((lesson) => (
    <tr key={lesson.id}>
      <td>{lesson.id}</td>
      <td>{lesson.name}</td>
      <td>
        <Button onClick={() => registerLesson({ogrenciId,dersId:lesson.id})}>Kaydol</Button>
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
