<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Project;
use AppBundle\Form\ProjectType;
use AppBundle\Repository\ProjectRepository;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ProjectController extends Controller
{
    /**
     * @Route("/", name="homepage")
     */
    public function index(Request $request)
    {
        $projects = $this
            ->getDoctrine()
            ->getRepository(Project::class)
            ->findAll();

        return $this->render("project/index.html.twig", ['projects'=>$projects]);
    }

    /**
     * @Route("/create", name="create")
     */
    public function create(Request $request)
    {
        $project = new Project();
        $form = $this->createForm(ProjectType::class,$project);

        $form->handleRequest($request);

        if ($form->isSubmitted()){
            $em = $this->getDoctrine()->getManager();
            $em->persist($project);
            $em->flush();

            return $this->redirect('/');
        }

        return $this->render('project/create.html.twig', ['form'=>$form->createView()]);
    }

    /**
     * @Route("/edit/{id}", name="edit")
     */

    public function edit($id, Request $request)
    {
        $project = $this->getDoctrine()->getRepository(Project::class)->find($id);

        $form = $this->createForm(ProjectType::class,$project);
        $form->handleRequest($request);

        if ($form->isSubmitted()){
            $em = $this->getDoctrine()->getManager();
            $em->persist($project);
            $em->flush();

            return $this->redirect('/');
        }

        return $this->render('project/edit.html.twig', ['form'=>$form->createView(), 'project'=>$project]);
    }

    /**
     * @Route("/delete/{id}", name="delete")
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\RedirectResponse|\Symfony\Component\HttpFoundation\Response
     */
    public function delete($id, Request $request)
    {
        $project = $this->getDoctrine()->getRepository(Project::class)->find($id);

        $form = $this->createForm(ProjectType::class,$project);
        $form->handleRequest($request);

        if ($form->isSubmitted()){
            $em = $this->getDoctrine()->getManager();
            $em->remove($project);
            $em->flush();

            return $this->redirect('/');
        }

        return $this->render('project/delete.html.twig', ['form'=>$form->createView(), 'project'=>$project]);
    }
}
