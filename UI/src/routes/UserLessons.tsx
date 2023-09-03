import React, { useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { fetchAllUsers } from "../features/user/userSlice";
import { Table } from "@mantine/core";
import {useRegisteredLessonsQuery} from "../features/apiSlice"


const UsersLessons = () => {
  const { id } = useParams();
  console.log(id);
 
  const { data: lessons, isError ,isLoading } = useRegisteredLessonsQuery({id});
   console.log(lessons);

  const data =lessons?.length > 0 ? lessons?.map((lesson) => (
    <tr key={lesson.id}>
      <td>{lesson.id}</td>
      <td>{lesson.derS_ADI}</td>
    </tr>
  )): (<tr> <td colSpan={2}>Henüz ders kaydı yok</td> </tr>);

  return (
    <div>
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
            </tr>
          </thead>
          <tbody>{data}</tbody>
        </Table>
      )}
    </div>
  );
};

export default UsersLessons;
